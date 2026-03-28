using AuthService.Domain.Interfaces;
using MediatR;

namespace AuthService.Application.Queries
{
    // 1. The DTO (What Angular will receive)
    public record UserDto(Guid Id, string FullName, string Email, string Role);

    // 2. The Request
    public record GetUsersQuery() : IRequest<IEnumerable<UserDto>>;

    // 3. The Handler
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);

            // Map the database entities to safe DTOs for the frontend
            return users.Select(u => new UserDto(
                u.Id,
                u.FullName,
                u.Email,
                u.Role.ToString()
            ));
        }
    }
}