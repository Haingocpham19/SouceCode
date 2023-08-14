using Core.CustomException;
using iChiba.OM.Service.Interface;
using iChiba.Portal.Common;
using iChiba.Portal.CustomException;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class CustomerWalletAppService : BaseAppService, ICustomerWalletAppService
    {
        private readonly ICurrentContext _currentContext;
        private readonly ICustomerWalletService _customerWalletService;
        private readonly IDepositsService _depositsService;
        private readonly IWithdrawalService _withdrawalService;
        private readonly IFreezeService _freezeService;
        private readonly IPaymentService _paymentService;

        public CustomerWalletAppService(
            ILogger<CustomerAppService> logger,
            ICurrentContext currentContext,
            ICustomerWalletService customerWalletService,
            IDepositsService depositsService,
            IWithdrawalService withdrawalService,
            IFreezeService freezeService,
            IPaymentService paymentService
        ) : base(logger)
        {
            _currentContext = currentContext;
            _customerWalletService = customerWalletService;
            _depositsService = depositsService;
            _withdrawalService = withdrawalService;
            _freezeService = freezeService;
            _paymentService = paymentService;
        }

        public Task<CustomerWalletResponse> GetCustomerWalletInfo()
        {
            var response = new CustomerWalletResponse();

            TryCatch(() =>
            {
                var customerWallet = _customerWalletService.GetByAccountId(_currentContext.UserId);
                if (customerWallet == null)
                    response.SetData(new CustomerWalletViewModel
                    {
                        AccountId = _currentContext.UserId,
                        WalletId = null,
                        Cash = 0,
                        CashFreeze = 0,
                        Point = 0,
                        TotalDeposit = 0,
                        TotalPay = 0,
                        TotalWithDawal = 0
                    }).Successful();
                else
                    response.SetData(customerWallet.ToModel()).Successful();
            }, response);

            return Task.FromResult(response);
        }

        public Task<DepositsHistoryResponse> GetListDepositsTransaction(WalletTransactionRequest request)
        {
            var response = new DepositsHistoryResponse();

            TryCatch(() =>
            {
                var sorts = request.Sorts;
                var paging = request.ToPaging();

                var deposits = _depositsService.GetListDeposits(
                    _currentContext.UserId, request.FromDate, request.ToDate,
                    request.Status, sorts, paging
                ).ToList();

                if (deposits == null || deposits.Count <= 0)
                {
                    response.SetData(new List<DepositsHistoryViewModel>()).Successful();
                }
                else
                {
                    var depositsViewModels = deposits.Select(x =>
                    {
                        var item = x.ToModel();
                        item.CreateDateStr = x.CreatedDate.ToString("dd/MM/yyyy");
                        return item;
                    }).ToList();

                    CultureInfo culture2 = new CultureInfo("en-US");
                    var depositsGroups = depositsViewModels.GroupBy(x => x.CreateDateStr);
                    var data = depositsGroups.Select(x =>
                    {
                        var item = new DepositsHistoryViewModel();
                        item.CreatedDate = DateTime.ParseExact(x.Key, "dd/MM/yyyy", culture2, DateTimeStyles.None);

                        item.CreatedDateDisplay = Utility.GetDateDisplay(item.CreatedDate);

                        item.Deposits = x.ToList();
                        return item;
                    }).ToList();

                    response.FromPaging(paging).SetData(data).Successful();
                }
            }, response);

            return Task.FromResult(response);
        }

        public Task<FreezeHistoryResponse> GetListFreezeTransaction(WalletTransactionRequest request)
        {
            var response = new FreezeHistoryResponse();

            TryCatch(() =>
            {
                var sorts = request.Sorts;
                var paging = request.ToPaging();

                var freezes = _freezeService.GetListFreeze(
                    _currentContext.UserId, request.FromDate, request.ToDate,
                    request.Status, sorts, paging
                ).ToList();

                if (freezes == null || freezes.Count <= 0)
                {
                    response.SetData(new List<FreezeHistoryViewModel>()).Successful();
                }
                else
                {
                    var freezeViewModels = freezes.Select(x =>
                    {
                        var item = x.ToModel();
                        item.CreateDateStr = x.CreatedDate.ToString("dd/MM/yyyy");
                        return item;
                    }).ToList();

                    CultureInfo culture2 = new CultureInfo("en-US");
                    var freezeGroups = freezeViewModels.GroupBy(x => x.CreateDateStr);
                    var data = freezeGroups.Select(x =>
                    {
                        var item = new FreezeHistoryViewModel();
                        item.CreatedDate = DateTime.ParseExact(x.Key, "dd/MM/yyyy", culture2, DateTimeStyles.None);

                        item.CreatedDateDisplay = Utility.GetDateDisplay(item.CreatedDate);

                        item.Freezes = x.ToList();
                        return item;
                    }).ToList();
                    response.FromPaging(paging).SetData(data).Successful();
                }
            }, response);

            return Task.FromResult(response);
        }

        public Task<WithdrawalHistoryResponse> GetListWithdrawalTransaction(WalletTransactionRequest request)
        {
            var response = new WithdrawalHistoryResponse();

            TryCatch(() =>
            {
                var sorts = request.Sorts;
                var paging = request.ToPaging();

                var withdrawals = _withdrawalService.GetListWithdrawal(
                    _currentContext.UserId, request.FromDate, request.ToDate,
                    request.Status, sorts, paging
                ).ToList();

                if (withdrawals == null || withdrawals.Count <= 0)
                {
                    response.SetData(new List<WithdrawalHistoryViewModel>()).Successful();
                }
                else
                {
                    var withdrawalViewModels = withdrawals.Select(x =>
                    {
                        var item = x.ToModel();
                        item.CreateDateStr = x.CreatedDate.ToString("dd/MM/yyyy");
                        return item;
                    }).ToList();

                    CultureInfo culture2 = new CultureInfo("en-US");
                    var withdrawalGroups = withdrawalViewModels.GroupBy(x => x.CreateDateStr);
                    var data = withdrawalGroups.Select(x =>
                    {
                        var item = new WithdrawalHistoryViewModel();
                        item.CreatedDate = DateTime.ParseExact(x.Key, "dd/MM/yyyy", culture2, DateTimeStyles.None);

                        item.CreatedDateDisplay = Utility.GetDateDisplay(item.CreatedDate);

                        item.Withdrawals = x.ToList();
                        return item;
                    }).ToList();
                    response.FromPaging(paging).SetData(data).Successful();
                }
            }, response);

            return Task.FromResult(response);
        }

        public Task<WalletTransactionResponse> GetWalletTransactionHistory(WalletTransactionRequest request)
        {
            var response = new WalletTransactionResponse();

            TryCatch(() =>
            {
                var paging = request.ToPaging();

                var deposits = _depositsService.GetListDeposits(_currentContext.UserId, request.FromDate, request.ToDate, request.Status)
                    .Select(x => new MoneyTransactionViewModel
                    {
                        Code = x.BankDescription,
                        Amount = x.Amount,
                        CreatedDate = x.CreatedDate,
                        CreateDateStr = x.CreatedDate.ToString("dd/MM/yyyy"),
                        Description = x.Note,
                        FTCode = x.Ftcode,
                        ProcessedDate = x.ProcessDate,
                        Status = x.DepositStatus,
                        TransactionType = "DEPOSITS"
                    });
                var freezes = _freezeService.GetListFreeze(_currentContext.UserId, request.FromDate, request.ToDate, request.Status)
                    .Select(x => new MoneyTransactionViewModel
                    {
                        Code = null,
                        Amount = x.Amount,
                        CreatedDate = x.CreatedDate,
                        CreateDateStr = x.CreatedDate.ToString("dd/MM/yyyy"),
                        Description = x.Description,
                        FTCode = null,
                        ProcessedDate = null,
                        Status = x.Status,
                        TransactionType = "FREEZE"
                    });
                var withdrawals = _withdrawalService.GetListWithdrawal(_currentContext.UserId, request.FromDate, request.ToDate, request.Status)
                    .Select(x => new MoneyTransactionViewModel
                    {
                        Code = x.Code,
                        Amount = x.Amount,
                        CreatedDate = x.CreatedDate,
                        CreateDateStr = x.CreatedDate.ToString("dd/MM/yyyy"),
                        Description = x.Note,
                        FTCode = x.Ftcode,
                        ProcessedDate = x.ProcessDate,
                        Status = x.WithDrawalStatus,
                        TransactionType = "WITHDRAWAL"
                    });

                var transactions = deposits.Concat(freezes).Concat(withdrawals)
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                if (transactions == null || transactions.Count <= 0)
                {
                    response.Total = 0;
                    response.SetData(new List<WalletTransactionViewModel>()).Successful();
                }
                else
                {
                    CultureInfo culture2 = new CultureInfo("en-US");
                    var transactionGroups = transactions.GroupBy(x => x.CreateDateStr);
                    var data = transactionGroups.Select(x =>
                    {
                        var item = new WalletTransactionViewModel();
                        item.CreatedDate = DateTime.ParseExact(x.Key, "dd/MM/yyyy", culture2, DateTimeStyles.None);

                        item.CreatedDateDisplay = Utility.GetDateDisplay(item.CreatedDate);

                        item.Transactions = x.ToList();
                        return item;
                    }).ToList();

                    
                    response.FromPaging(paging).SetData(data).Successful();
                    response.Total = deposits.Count() + freezes.Count() + withdrawals.Count();
                }
            }, response);

            return Task.FromResult(response);
        }

        public Task<DebtResponse> GetDebtInfo()
        {
            var response = new DebtResponse();

            TryCatch(() =>
            {
                var customerWallet = _customerWalletService.GetByAccountId(_currentContext.UserId);
                if (customerWallet != null)
                {
                    var payments = _paymentService.GetByAccountId(_currentContext.UserId)
                        .Where(x => x.Refund != true && x.Status != PaymentStatus.WaitProcess.GetHashCode() && x.Status != PaymentStatus.Cancel.GetHashCode());

                    var deposits = _depositsService.GetByAccountId(_currentContext.UserId)
                        .Where(x => x.DepositStatus == DepositStatus.Processed.GetHashCode());

                    var withdrawals = _withdrawalService.GetByAccountId(_currentContext.UserId)
                        .Where(x => x.WithDrawalStatus == WithdrawalStatus.Processed.GetHashCode());

                    var data = new DebtViewModel
                    {
                        Cash = customerWallet.Cash,
                        CashFreeze = customerWallet.CashFreeze,
                        TotalDeposits = deposits.Sum(x => x.Amount),
                        TotalWithdrawal = withdrawals.Sum(x => x.Amount),
                        TotalPay = payments.Where(x => x.Status == PaymentStatus.Processed.GetHashCode()).Sum(x => x.Amount),
                        TotalWaitPayment = payments.Where(x => x.Status == PaymentStatus.Approved.GetHashCode()).Sum(x => x.Amount)
                    };

                    response.SetData(data).Successful();
                }
                else
                {
                    var data = new DebtViewModel
                    {
                        Cash = 0,
                        CashFreeze = 0,
                        TotalDeposits = 0,
                        TotalWithdrawal = 0,
                        TotalPay = 0,
                        TotalWaitPayment = 0
                    };

                    response.SetData(data).Successful();
                }
            }, response);

            return Task.FromResult(response);
        }
    }
}
