using System.Text.RegularExpressions;
using System;
using System.ComponentModel.DataAnnotations;

namespace CGV_BackEnd.Models
{
	public class Address
	{
		[Key]
		public string? Id { get; set; }
		public string Street { get; set; }
		public string Neighborhood { get; set; }
		public State State { get; set; }
		public string Cep { get; set; }
		public string Number { get; set; }
		public string Complement { get; set; } = string.Empty;
		public string LawyerId { get; set; } // Chave estrangeira

		public Address(State state, string cep, string street, string neighborhood, string number, string complement = "")
		{
			State = state;
			Cep = cep;
			Street = street;
			Neighborhood = neighborhood;
			Number = number;
			Complement = complement;
		}

		public bool ValidateCep()
		{
			var cepRegex = new Regex(@"^[0-9]{5}-[0-9]{3}$");
			return cepRegex.IsMatch(Cep);
		}
	}

	public enum State
	{
		AC, // Acre
		AL, // Alagoas
		AP, // Amapá
		AM, // Amazonas
		BA, // Bahia
		CE, // Ceará
		DF, // Distrito Federal
		ES, // Espírito Santo
		GO, // Goiás
		MA, // Maranhão
		MT, // Mato Grosso
		MS, // Mato Grosso do Sul
		MG, // Minas Gerais
		PA, // Pará
		PB, // Paraíba
		PR, // Paraná
		PE, // Pernambuco
		PI, // Piauí
		RJ, // Rio de Janeiro
		RN, // Rio Grande do Norte
		RS, // Rio Grande do Sul
		RO, // Rondônia
		RR, // Roraima
		SC, // Santa Catarina
		SP, // São Paulo
		SE, // Sergipe
		TO  // Tocantins
	}


}
