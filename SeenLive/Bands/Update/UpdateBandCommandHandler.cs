using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.Update
{
    public class UpdateBandCommandHandler
    : HandlerBase, IRequestHandler<UpdateBandCommand, IHandlerResult<BandViewModel>>
    {
        public async Task<IHandlerResult<BandViewModel>> Handle(UpdateBandCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
