using System;
using System.Collections.Concurrent;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Concurrent
{
    public class CodeConcurrentManager
    {
        private readonly ConcurrentDictionary<string, object> transactionLocks = new ConcurrentDictionary<string, object>();
        private readonly object transactionLock = new object();

        public object GetTransactionLock(string code)
        {
            lock (transactionLock)
            {
                if (transactionLocks.TryGetValue(code, out var value))
                {
                    return value;
                }

                value = new object();

                if (!transactionLocks.TryAdd(code, value))
                {
                    throw new Exception($"Can't add lock object for code = {code}");
                }

                return value;
            }
        }
    }
}
