using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;

namespace DevIO.App.Extensions
{
    public class MoedaAttributeAdapter : AttributeAdapterBase<MoedaAttribute>
    {

        public MoedaAttributeAdapter(MoedaAttribute moedaAttribute, IStringLocalizer stringLocalizer) : base(moedaAttribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            MergeAttribute(context.Attributes, key: "data-val", value: "true");
            MergeAttribute(context.Attributes, key: "data-val-moeda", value: GetErrorMessage(context));
            MergeAttribute(context.Attributes, key: "data-val-number", value: GetErrorMessage(context));
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return "Moeda em formato inválido!";
        }
    }
}
