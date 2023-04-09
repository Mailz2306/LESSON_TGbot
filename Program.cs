using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

TelegramBotClient client = new TelegramBotClient("5869589674:AAF47hFU4uWzHdIYykADeR6_BmARsvuclnQ");

User user = await client.GetMeAsync();

Console.WriteLine(user.Username);

while (true)
{
    Update[] updates = await client.GetUpdatesAsync();

    for (var i = 0; i < updates.Length; i++)
    {
        Console.WriteLine(updates[i].Message.Text);
        Console.WriteLine(updates[i].Message.From.FirstName);
        Console.WriteLine(updates[i].Message.From.Username);

        if(updates[i].Message.Text == "Привет")
        {
            await client.SendTextMessageAsync(updates[i].Message.From.Id, "И тебе привет?");
        }
        else
        {
            await client.SendTextMessageAsync(updates[i].Message.From.Id, "Спасибо за помощь");
        }

    }
    if (updates.Length != 0)
    {
        updates = await client.GetUpdatesAsync(updates[updates.Length - 1].Id + 1);
    }
}