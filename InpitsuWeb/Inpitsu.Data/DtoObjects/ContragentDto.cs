using Inpitsu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.DtoObjects
{
    public record ContragentDto(
         Guid? Id,
         string? Name,
         string? Description,
         string? Address,
         string? Contact,
         long? Pin,
         long? Inn,
         string? Email

    );
    public record ContragentCreateDto(
        Guid? Id,
         string? Name,
         string? Description,
         string? Address,
         string? Contact,
         long? Pin,
         long? Inn,
         string? Email
        );

    public record ContragentUpdateDto(
         Guid? Id,
         string? Name,
         string? Description,
         Address? Address,
         Contact? Contact,
         long? Pin,
         long? Inn,
         Email? Email
        );
    public record ContragentDeleteDto(Guid Id);
}