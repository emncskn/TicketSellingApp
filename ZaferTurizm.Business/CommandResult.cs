using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Business
{
    public class CommandResult
    {
        private const string DefaultSuccessMessage = "İşlem başarılı";
        private const string DefaultFailureMessage = "İşlem başarısız";
        public bool IsSuccess { get;private set; }
        public string Message { get; private set; } //private yaparak set yetkisini elime aldım.

        //Factory Pattern :sürekli aynı nesneyi üretiyorsan kullanılabilir.

        public static CommandResult Success()
        {
            return Success(DefaultSuccessMessage);
        }

        public static CommandResult Success(string message)
        {
            return new CommandResult
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static CommandResult Failure()
        {
            return Failure(DefaultFailureMessage);
        }

        public static CommandResult Failure(string message)
        {
            return new CommandResult
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}