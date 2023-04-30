using BLL.Helpers;
using BLL.Interfaces;
using BLL.Validations;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Messager;

namespace BLL.Services;

public class MessageService : IMessageService
{
    private readonly IUnitOfWork _unitOfWork;

    public MessageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CheckOTP(string phoneNumber, int code)
    {
        if (phoneNumber == null || code < 0)
        {
            return false;
        }

        var otp = (await _unitOfWork.VerificationCodes.GetAllAsync())
                         .FirstOrDefault(i => i.PhoneNumber == phoneNumber);
        if (otp == null)
        {
            return false;
        }

        var otpIsExpired = otp.ExpireDate < LocalTime.GetUtc5Time();
        if (otpIsExpired)
        {
            await _unitOfWork.VerificationCodes.RemoveAsync(otp);
            await _unitOfWork.SaveAsync();
            return false;
        }

        if (otp.Code == code)
        {
            await _unitOfWork.VerificationCodes.RemoveAsync(otp);
            await _unitOfWork.SaveAsync();
            return true;
        }
        return false;
    }

    public async Task<string> SendOTP(string phoneNumber, string IPAdress)
    {
        var otp = (await _unitOfWork.VerificationCodes.GetAllAsync())
                         .FirstOrDefault(i => i.PhoneNumber == phoneNumber);
        if (otp != null)
        {
            await _unitOfWork.VerificationCodes.RemoveAsync(otp);
            await _unitOfWork.SaveAsync();
        }

        using var messager = new Message();
        var request = await messager.SendSMSAsync(phoneNumber);
        if (request.Success)
        {
            VerificationCode verificationCode = new()
            {
                AddedDate = LocalTime.GetUtc5Time(),
                ModifiedDate = LocalTime.GetUtc5Time(),
                IPAdress = IPAdress,
                ExpireDate = LocalTime.GetUtc5Time().AddMinutes(1),
                PhoneNumber = phoneNumber,
                IsDeleted = false,
                Code = request.Code
            };

            await _unitOfWork.VerificationCodes.AddAsync(verificationCode);
            await _unitOfWork.SaveAsync();

            return phoneNumber;
        }
        else
        {
            throw new MarketException(request.Message);
        }
    }
}