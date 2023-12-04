
using System.Net;
using System.Text.Json;
﻿using System.Net.Http;


class Program
{
	public static async Task BoredSearchAsync()
	{
		while (true)
		{ 
		Console.WriteLine("Find an activity to stop the boredom! ");
		Console.WriteLine("Please choose from: education, recreational, social, diy, charity, cooking, relaxation, music or busywork");

		string enteredType = Console.ReadLine();
			Console.WriteLine("\n ");

			if (!IsValidInput(enteredType))
		{
			Console.WriteLine("Please enter a valid activity from the provided list.");
			return;
		}
			try
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://www.boredapi.com/api/activity/");

					var response = await client.GetAsync($"?type={enteredType}");

					if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					var getResponse = JsonSerializer.Deserialize<GetResponse>(responseContent);

					if (string.IsNullOrEmpty(enteredType))
					{
						Console.WriteLine("Please choose from one below");
						Console.WriteLine(getResponse.count);

						foreach (var bored in getResponse.results)
						{
							Console.WriteLine("Name: " + bored.activity);
							Console.WriteLine("URL: " + bored.url);

							Console.WriteLine("---------------------");
						}
					}
					else
					{
						Console.WriteLine($"Activity: {getResponse.activity}");
						Console.WriteLine($"Accessibility: {getResponse.accessibility}");
						Console.WriteLine($"Type: {getResponse.type}");
						Console.WriteLine($"Participants: {getResponse.participants}");
						Console.WriteLine($"Price: £{getResponse.price}");
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
			Console.WriteLine("Do you want to search again? (yes/no)");
			string restartChoice = Console.ReadLine().ToLower();

			if (restartChoice != "yes")
			{
				break; 
			}
		}
	}

	private static bool IsValidInput(string enteredName)
	{
		string[] validInputs = { "education", "recreational", "social", "diy", "charity", "cooking", "relaxation", "music", "busywork" };
		return validInputs.Contains(enteredName.ToLower());
	}

	static async Task Main(string[] args)
	{
		await BoredSearchAsync();
	}
}