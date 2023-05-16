using BLL.Dtos.LoanDtos;
using BLL.Dtos.LoanPaymentDtos;
using BLL.Dtos.WarehouseDtos;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Validations;
using Core;
using DataLayer.Entities.Selling;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class LoanService : ILoanService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> userManager;

    public LoanService(IUnitOfWork unitOfWork,
                       UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        this.userManager = userManager;
    }

    public async Task AddAsync(AddLoanDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        Loan loan = new()
        {
            AddedDate = LocalTime.GetUtc5Time(),
            ModifiedDate = LocalTime.GetUtc5Time(),
            IsDeleted = false,
            SellerId = dto.SellerId,
            CustomerId = dto.CustomerId,
            ReceiptId = dto.ReceiptId,
            PaidCard = dto.PaidCard,
            PaidCash = dto.PaidCash,
            LeftAmount = dto.LeftAmount,
            TotalPayment = dto.TotalPayment
        };

        await _unitOfWork.Loans.AddAsync(loan);
        await _unitOfWork.SaveAsync();
    }

    public async Task<PagedList<LoanViewDto>> GetAllPagedAsync(int pageSize, int pageNumber)
    {
        var dtoList = (await _unitOfWork.Loans.GetAllAsync())
                                                   .Where(w => w.IsDeleted == false)
                                                   .OrderByDescending(i => i.ModifiedDate)
                                                   .ToList();

        if (dtoList.Count == 0)
        {
            throw new MarketException("Empty list");
        }

        var customers = await _unitOfWork.Customers.GetAllAsync();
        var sellers = await userManager.Users.ToListAsync();
        var payments = await _unitOfWork.LoanPayments.GetAllAsync();

        var loanViewDtos = dtoList.Select(loan =>
            new LoanViewDto()
            {
                Id = loan.Id,
                PaidCard = loan.PaidCard,
                PaidCash = loan.PaidCash,
                ReceiptId = loan.ReceiptId,
                TotalPayment = loan.TotalPayment,
                LeftAmount = loan.LeftAmount,
                CustomerId = loan.CustomerId,
                CustomerFullName = customers.FirstOrDefault(c => c.Id == loan.CustomerId).FullName,
                SellerId = loan.SellerId,
                SellerFullName = sellers.FirstOrDefault(s => s.Id == loan.SellerId).FullName,
                Payments = payments.Where(p => p.LoanId == loan.Id)
                                   .Select(i => new LoanPaymentViewDto()
                                   {
                                       Id = i.Id,
                                       PaidDate = i.AddedDate,
                                       LoanId = i.LoanId,
                                       PaidCard = i.PaidCard,
                                       PaidCash = i.PaidCash,
                                       TotalPayment = i.TotalPayment,
                                       SellerId = i.SellerId,
                                       SellerFullName = sellers.FirstOrDefault(s => s.Id == loan.SellerId).FullName
                                   })
                                   .ToList()
            });


        PagedList<LoanViewDto> pagedList = new(loanViewDtos.ToList(),
                                                     dtoList.Count(),
                                                     pageNumber, pageSize);

        if (pageNumber > pagedList.TotalPages || pageNumber < 1)
        {
            throw new ArgumentNullException("Page not fount!");
        }

        return pagedList.ToPagedList(loanViewDtos, pageSize, pageNumber);
    }
}