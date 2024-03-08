using System.Security.Cryptography;
using System.Text;
using Application.Dtos;
using Application.Exceptions;
using Application.Services.Abstractions;
using Application.Utilities;
using AutoMapper;
using DataAccess.CodeForms.Enums;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IBaseRepository<Account> _accountRepository;
    private readonly IBaseRepository<Employee> _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthenticationService(IBaseRepository<Account> accountRepository, IBaseRepository<Employee> employeeRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<EmployeeDto> Login(AccountDto accountDto)
    {
        try
        {
            var account = await _accountRepository.Get(a => a.Email == accountDto.Email);
            if (account.Password != HashPassword(accountDto.Password))
            {
                throw new InvalidLoginOrPasswordException();
            }

            var employee = await _employeeRepository.Get(e => e.Account.Email == account.Email);
            return _mapper.Map<EmployeeDto>(employee);
        }
        catch (ArgumentNullException)
        {
            throw new InvalidLoginOrPasswordException();
        }
        
    }

    public async Task<EmployeeDto> Register(AccountDto accountDto, EmployeeDto employeeDto)
    {
        Account? foundAccount = await _accountRepository.Find(a => a.Email == accountDto.Email);
        if (foundAccount is not null)
        {
            throw new AccountWithEmailAlreadyExistException(foundAccount.Email);
        }
        
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
                _unitOfWork.BeginTransaction();
                
                var account = _mapper.Map<Account>(accountDto);
                account.Password = HashPassword(account.Password);
                account = await _accountRepository.Add(account);

                var employee = new Employee(employeeDto.Name,
                    ParseUtility.ParseEnum<Department>(employeeDto.Department));
                employee.Account = account;
                employee = await _employeeRepository.Add(employee);

                await _unitOfWork.SaveChangesAsync();
                var newEmployee = _mapper.Map<EmployeeDto>(employee);
                transaction.Commit();
                return newEmployee;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}