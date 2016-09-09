using Models.Models;

namespace Models.Data
{
	public class PersonRepo : IPersonRepo
	{
		private readonly Person[] _personRepo;

		public PersonRepo()
		{
			_personRepo = new[]
			{
				new Person {FirstName = "Guybrush", LastName = "Threepwood", PersonId = 1},
				new Person {FirstName = "Arthas", LastName = "Menethil", PersonId = 2},
				new Person {FirstName = "Illidan", LastName = "Stormrage", PersonId = 3},
				new Person {FirstName = "Falstad", LastName = "Wildhammer", PersonId = 4},
				new Person {FirstName = "Garrosh", LastName = "Hellscream", PersonId = 5},
				new Person {FirstName = "Jaina", LastName = "Proudmoore", PersonId = 6},
			};
		}

		public Person[] GetAll()
		{
			return _personRepo;
		}
	}
}