using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using businessModel = ProjectManagement.Domain.BusinessModels.Models;

namespace ProjectMangement.Application.Validators
{
    public class Model3DValidator : AbstractValidator<businessModel.Model3D>
    {
        public Model3DValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .Must(x => x.Length < 400)
                .WithMessage("Description is invalid");

            RuleFor(x => x.PolygoneCount)
                .NotEmpty()
                .Must(x => x < 1000)
                .WithMessage("Polygone count is too high for this 3d model");
        }
    }
}
