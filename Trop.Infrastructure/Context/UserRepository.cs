using Trop.Application.Common.Repository;
using Trop.Domain.Models.User;

namespace Trop.Infrastructure.Context;

public class UserRepository(TropContext context) : TropRepository<UserEntity>(context), IUserRepository;
