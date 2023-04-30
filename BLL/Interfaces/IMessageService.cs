using BLL.Dtos.MessageDtos;

namespace BLL.Interfaces;

public interface IMessageService
{
    Task<string> SendOTP(string phoneNumber, string IPAdress);
    Task<bool> CheckOTP(string phoneNumber, int code);
} 