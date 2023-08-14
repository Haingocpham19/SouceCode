using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace iChiba.Portal.Cache.Model
{
    [ProtoContract]
    public class ShoppingCarts
    {
        public const string CURRENT_CART_KEY = "CURRENT_CART_KEY";
        public const string TEMP_CART_KEY = "TEMP_CART_KEY";

        public readonly IReadOnlyList<string> CartKeys = new List<string>()
        {
            CURRENT_CART_KEY,
            TEMP_CART_KEY
        };

        [ProtoMember(1)]
        public string IdentityRefId { get; set; }

        [ProtoMember(2)]
        public IDictionary<string, ShoppingCart> Carts { get; set; }

        [ProtoMember(3)]
        public DateTime CreatedDate { get; set; }

        public ShoppingCart Current => GetByKey(CURRENT_CART_KEY);

        public ShoppingCart Temp => GetByKey(TEMP_CART_KEY);

        public ShoppingCarts(string identityRefId = null)
        {
            if (string.IsNullOrWhiteSpace(identityRefId))
            {
                identityRefId = Guid.NewGuid().ToString();
            }

            IdentityRefId = identityRefId;
            Carts = new Dictionary<string, ShoppingCart>();
        }

        public ShoppingCarts()
            : this(null)
        {
        }

        public void Init()
        {
            foreach (var item in CartKeys)
            {
                if (Carts.ContainsKey(item))
                {
                    continue;
                }

                var cart = new ShoppingCart();

                Carts.Add(item, cart);
            }
        }

        public ShoppingCart GetByKey(string key)
        {
            if (!Carts.ContainsKey(key))
            {
                return null;
            }

            return Carts[key];
        }

        public void SetByKey(string key, ShoppingCart model)
        {
            Carts[key] = model;
        }

        public void SetCurrent(ShoppingCart model)
        {
            SetByKey(CURRENT_CART_KEY, model);
        }

        public void SetTemp(ShoppingCart model)
        {
            SetByKey(TEMP_CART_KEY, model);
        }

        public void Merge(ShoppingCarts model)
        {
            foreach (var item in model.Carts)
            {
                var cart = GetByKey(item.Key);

                if (cart == null)
                {
                    SetByKey(item.Key, item.Value);

                    continue;
                }

                cart.Merge(item.Value);
            }
        }

        public static ShoppingCarts CreateInstance(string identityRefId = null)
        {
            var cart = new ShoppingCarts(identityRefId);

            cart.Init();

            return cart;
        }
    }

    [ProtoContract]
    public class ShoppingCart
    {
        [ProtoMember(1)]
        public IList<ShoppingCartItem> Items { get; set; }
        [ProtoMember(2)]
        public DateTime CreatedDate { get; set; }

        public decimal Amount
        {
            get
            {
                return CalculateTotalAmount(Items);
            }
        }
        
        public ShoppingCart()
        {
            CreatedDate = DateTime.UtcNow;
            Items = new List<ShoppingCartItem>();
        }

        public void Add(ShoppingCartItem model)
        {
            using (var transaction = new TransactionScope())
            {
                var currentModel = GetById(model.Id);

                if (currentModel != null)
                {
                    model.CreatedDate = currentModel.CreatedDate;
                }

                Remove(model.Id);
                Items.Add(model);
                transaction.Complete();
            }
        }

        private ShoppingCartItem GetById(string id)
        {
            return Items.FirstOrDefault(m => m.Id.Equals(id));
        }

        public void Remove(string id)
        {
            Items = Items.Where(m => !m.Id.Equals(id)).ToList();
        }

        public void Remove(string refType, string sellerId)
        {
            Items = Items.Where(m => !(m.RefType.Equals(refType) && string.Compare(m.SellerId, sellerId) == 0)).ToList();
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void Merge(IList<ShoppingCartItem> items)
        {
            items.ToList().ForEach(item =>
            {
                var currentItem = GetById(item.Id);

                if (currentItem == null)
                {
                    Add(item);

                    return;
                }

                if (currentItem.CreatedDate > item.CreatedDate)
                {
                    return;
                }

                Add(item);
            });
        }

        public void Merge(ShoppingCart model)
        {
            Merge(model.Items);
        }

        public IList<ShoppingCartItem> GetByRefType(string refType)
        {
            return Items.Where(m => m.RefType.Equals(refType)).ToList();
        }

        public IList<ShoppingCartItem> GetByRefTypeAndSellerId(string refType, string sellerId)
        {
            return Items.Where(m => m.RefType.Equals(refType) && m.SellerId.Equals(sellerId)).ToList();
        }

        public decimal CalculateTotalAmount(IList<ShoppingCartItem> items)
        {
            var amount = items.Sum(m => m.Amount);

            return amount;
        }

    }

    [ProtoContract]
    public class ShoppingCartItem
    {
        public string Id
        {
            get
            {
                const string SEPARATOR = "-";
                var id = $"{RefType}{SEPARATOR}{Ref}{ProductName}";

                if (Attributes == null)
                {
                    id = Core.Common.Utility.Md5Hash(id);
                    return id;
                }

                var items = Attributes.Where(m => !string.IsNullOrWhiteSpace(m.Key) && !string.IsNullOrWhiteSpace(m.Value))
                    .Select(m => $"{m.Key}{SEPARATOR}{m.Value}")
                    .ToList();

                items.Insert(0, RefType);
                items.Insert(0, Ref);

                id = string.Join(SEPARATOR, items.ToArray());
                id = Core.Common.Utility.Md5Hash(id);
                return id;
            }
        }

        [ProtoMember(1)]
        public IDictionary<string, string> Attributes { get; set; }

        [ProtoMember(2)]
        public string PreviewImage { get; set; }

        [ProtoMember(3)]
        public IList<string> Images { get; set; }

        [ProtoMember(4)]
        public int Quantity { get; set; }

        [ProtoMember(5)]
        public decimal Weight { get; set; }

        [ProtoMember(6)]
        public int Width { get; set; }

        [ProtoMember(7)]
        public int Height { get; set; }

        [ProtoMember(8)]
        public int Length { get; set; }

        [ProtoMember(9)]
        public decimal Price { get; set; }

        [ProtoMember(10)]
        public int Tax { get; set; }

        [ProtoMember(11)]
        public string Ref { get; set; }

        [ProtoMember(12)]
        public string RefType { get; set; }

        [ProtoMember(13)]
        public DateTime CreatedDate { get; set; }

        [ProtoMember(14)]
        public string ProductName { get; set; }

        [ProtoMember(15)]
        public string ProductLink { get; set; }

        [ProtoMember(16)]
        public string NoteOrder { get; set; }

        [ProtoMember(17)]
        public string SellerId { get; set; }

        [ProtoMember(18)]
        public int ShippingFee { get; set; }

        [ProtoMember(19)]
        public string Currency { get; set; }

        [ProtoMember(20)]
        public string AccountId { get; set; }

        [ProtoMember(21)]
        public IList<string> ServiceCode { get; set; }

        [ProtoMember(22)]
        public string TrackingNote { get; set; }

        [ProtoMember(23)]
        public string Warehouse { get; set; }
        [ProtoMember(24)]
        public string Color { get; set; }
        [ProtoMember(25)]
        public string Size { get; set; }
        [ProtoMember(26)]
        public string SourceName { get; set; }
        public decimal Amount
        {
            get
            {
                return Price * Quantity;
            }
        }

        public ShoppingCartItem()
        {
            ServiceCode = new List<string>();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
