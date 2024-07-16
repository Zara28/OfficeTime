
using Telegram.Bot;
using Telegram.Bot.Types;

var bot = new TelegramBotClient("7219448285:AAHraSpG_AMvOTrttnl25mbhR8iq2N8Qp9Q");
bot.StartReceiving(OnMessage, OnError);
while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

async Task OnError(ITelegramBotClient client, Exception exception, CancellationToken ct)
{
    Console.WriteLine(exception);
    await Task.Delay(2000, ct);
}



async Task OnMessage(ITelegramBotClient bot, Update update, CancellationToken ct)
{
    Console.WriteLine(update.Message.Text);
    await bot.SendTextMessageAsync(update.Message.Chat.Id, "fvffv");
}