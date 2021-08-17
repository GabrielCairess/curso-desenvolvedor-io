using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasColumnType("VARCHAR(8)");

            builder.Property(e => e.Complemento)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.ToTable("ENDERECOS");
        }
    }
}
