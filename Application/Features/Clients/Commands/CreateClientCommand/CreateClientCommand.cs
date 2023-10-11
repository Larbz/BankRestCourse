using Application.Wrappers;
using MediatR;

namespace Application.Features.Clients.Commands.CreateClientCommand;

public class CreateClientCommand : IRequest<Response<int>>
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    
    public class CreateClientCommandHandler:IRequestHandler<CreateClientCommand,Response<int>>
    {
        public async Task<Response<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}