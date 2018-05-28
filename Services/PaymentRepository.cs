using Microsoft.EntityFrameworkCore;
using Rcpg;
using RcpgMicroserviceClient.Entities;
using RcpgMicroserviceClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace RcpgMicroserviceClient.Services
{
    public interface IPaymentRepository
    {
        Task<Payment> Find(string token);
        Task<Payment> FindByTransactionId(string transactionId);
        Task<Payment> Track(string token);
        Task<Payment> TrackByTransactionId(string transactionId);
        Task<List<Payment>> GetAll();
        Task Add(Payment payment);
        Task Update(Payment payment);
        // Task SetAsExecuted(string token, string transactionId, int? additionalCosts, DateTime capturedOn);
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly RcpgClientDbContext dbContext;

        public PaymentRepository(RcpgClientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Payment> Find(string token)
            => await dbContext.Payments.AsNoTracking().SingleOrDefaultAsync(p => p.Token == token);

        public async Task<Payment> FindByTransactionId(string transactionId)
            => await dbContext.Payments.AsNoTracking().SingleOrDefaultAsync(p => p.TransactionId == transactionId);

        public async Task<Payment> Track(string token)
            => await dbContext.Payments.FindAsync(token);

        public async Task<Payment> TrackByTransactionId(string transactionId)
            => await dbContext.Payments.SingleOrDefaultAsync(p => p.TransactionId == transactionId);

        public async Task<List<Payment>> GetAll()
            => await dbContext.Payments.AsNoTracking().OrderByDescending(p => p.InitiatedOn).ToListAsync();

        public async Task Add(Payment payment)
        {
            dbContext.Entry(payment).State = EntityState.Added;
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Payment payment)
        {
            dbContext.Payments.Update(payment);
            await dbContext.SaveChangesAsync();
        }

        // public async Task SetAsExecuted(string token, string transactionId, int? additionalCosts, DateTime capturedOn)
        // {
        //     Payment payment = await dbContext.Payments.FindAsync(token);
        //     // Status depends on intent.
        //     payment.Status = Enum.Parse<Intent>(payment.Intent) == Intent.Sale
        //         ? PaymentStatus.Captured.ToString()
        //         : PaymentStatus.Authorized.ToString();
        //     payment.TransactionId = transactionId;
        //     payment.AdditionalCosts = additionalCosts;
        //     payment.CapturedOn = capturedOn;

        //     dbContext.Entry(payment).State = EntityState.Modified;
        //     await dbContext.SaveChangesAsync();
        // }
    }
}