using CommandCenter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCenter.Core.Interfaces.EventSenderHubs
{
    public interface IFrameworkEventSenderHub
    {
        Task UpdateGeneralStatusAsync(Framework entity);
    }
}
