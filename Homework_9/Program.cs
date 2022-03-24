using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions.Polling;
using System.Threading;
using Telegram.Bot.Types.ReplyMarkups;


namespace Homework_9
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var token = System.IO.File.ReadAllText("token.txt");

            var bot = new TelegramBotClient(token);
            var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };

            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = await bot.GetMeAsync();


            Console.WriteLine($"Start listening for @{me.Username}");

            Console.ReadKey();

            cts.Cancel();

            async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
            {
                if (update.Type != UpdateType.Message)
                    return;

                var chatId = update.Message.Chat.Id;
                const string password = "Aboba";

                Console.WriteLine($"Мне пишет: {update.Message.From.FirstName} {update.Message.From.LastName} {update.Message.From.Id}, id чата: {chatId}");

                if (update.Message!.Type == MessageType.Document)
                {
                    var messageDoc = update.Message.Document;
                    Console.WriteLine($"Вам отправили: {update.Message.Type}");
                    Download(messageDoc.FileId, messageDoc.FileName);
                    return;
                }

                if (update.Message!.Type == MessageType.Photo)
                {
                    var messagePhoto = update.Message.Photo;
                    Console.WriteLine($"Вам отправили: {update.Message.Type}");
                    Download(messagePhoto[3].FileId, $"Photo_{messagePhoto[3].FileId}.jpg");
                    return;
                }

                if (update.Message!.Type == MessageType.Audio)
                {
                    var messageAudio = update.Message.Audio;
                    Console.WriteLine($"Вам отправили: {update.Message.Type}");
                    Download(messageAudio.FileId, messageAudio.FileName);
                    return;
                }

                if (update.Message!.Type == MessageType.Video)
                {
                    var messageVideo = update.Message.Video;
                    Console.WriteLine($"Вам отправили: {update.Message.Type}");
                    Download(messageVideo.FileId, messageVideo.FileName);
                    return;
                }

                if (update.Message!.Type == MessageType.Text)
                {
                    var messageText = update.Message.Text;

                    Console.WriteLine($"Сообщение которое мне прислали: {messageText}");

                    if (messageText == "/start" || messageText == "/help")
                    {
                        await bot.SendTextMessageAsync(chatId, $"Привет, {update.Message.From.FirstName}!\n" +
                            $"Вот что я могу:\n" +
                            $"1. Здароваться\n" +
                            $"2. Отвечать на бибу и бобу\n" +
                            $"3. Принимать фото, видео, аудио и документы и скачивать их себе на компуктер");
                        Console.WriteLine("Бот дал информацию (/help)");
                    }

                    if (messageText == "боба" || messageText == "Боба")
                    {
                        await bot.SendTextMessageAsync(chatId, "Биба");
                        Console.WriteLine("Бот ответил: Биба");
                    }

                    if (messageText == "биба" || messageText == "Биба")
                    {
                        await bot.SendTextMessageAsync(chatId, "Боба");
                        Console.WriteLine("Бот ответил: Боба");
                    }

                    if (messageText == "hi" || messageText == "привет" || messageText == "Привет" || messageText == "Hello")
                    {
                        await bot.SendTextMessageAsync(chatId, $"Здравствуй, {update.Message.From.FirstName}!");
                        Console.WriteLine($"Бот ответил: {update.Message.From.FirstName}");
                    }

                    if (messageText == "Фото")
                    {
                        //Message messagePhoto = await bot.SendPhotoAsync(chatId, )
                    }

                    return;
                }



                async void Download(string fileId, string path)
                {
                    FileStream fs = new FileStream("F:/Учеба/Programing/Skillbox/Homework_9/bin/Debug/netcoreapp3.1/Media/_" + path, FileMode.Create);
                    await bot.GetInfoAndDownloadFileAsync(fileId, fs);
                    fs.Close();
                    fs.Dispose();
                }


                //Message message = await botClient.SendTextMessageAsync(
                //    chatId: chatId,
                //    text: "*Trying* all the parameters of `sendMessage` method",
                //    parseMode: ParseMode.MarkdownV2,
                //    disableNotification: true,
                //    replyToMessageId: update.Message.MessageId,
                //    replyMarkup: new InlineKeyboardMarkup(
                //        InlineKeyboardButton.WithUrl(
                //            "Check sendMessage method",
                //            "https://core.telegram.org/bots/api#sendmessage")),
                //    cancellationToken: cancellationToken);

                //Console.WriteLine(
                //        $"{message.From.FirstName} sent message {message.MessageId} " +
                //        $"to chat {message.Chat.Id} at {message.Date}. " +
                //        $"It is a reply to message {message.ReplyToMessage.MessageId} " +
                //        $"and has {message.Entities.Length} message entities.");


                //Message message = await botClient.SendPhotoAsync(
                //    chatId: chatId,
                //    photo: "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg",
                //    caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                //    parseMode: ParseMode.Html,
                //    cancellationToken: cancellationToken);

                //Message message1 = await botClient.SendStickerAsync(
                //    chatId: chatId,
                //    sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp",
                //    cancellationToken: cancellationToken);

                //Message message2 = await botClient.SendStickerAsync(
                //    chatId: chatId,
                //    sticker: message1.Sticker.FileId,
                //    cancellationToken: cancellationToken);

                //Message message = await botClient.SendAudioAsync(
                //    chatId: chatId,
                //    audio: "https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3",
                //    cancellationToken: cancellationToken);

                //            Message[] messages = await botClient.SendMediaGroupAsync(
                //                chatId: chatId,
                //                media: new IAlbumInputMedia[]
                //                {
                //                    new InputMediaPhoto("https://cdn.pixabay.com/photo/2017/06/20/19/22/fuchs-2424369_640.jpg"),
                //                    new InputMediaPhoto("https://cdn.pixabay.com/photo/2017/04/11/21/34/giraffe-2222908_640.jpg"),
                //                },
                //                cancellationToken: cancellationToken);
                //            Message message3 = await botClient.SendDocumentAsync(
                //chatId: chatId,
                //document: "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg",
                //caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                //parseMode: ParseMode.Html,
                //cancellationToken: cancellationToken);


            }


            Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException
                        => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };

                Console.WriteLine(ErrorMessage);
                return Task.CompletedTask;
            }
        }
    }
}
