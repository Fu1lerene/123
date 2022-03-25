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
            var token = System.IO.File.ReadAllText("token.txt"); /// считываем токен из файла

            var bot = new TelegramBotClient(token); /// создаем клиент бота
            var cts = new CancellationTokenSource(); /// сигнал отмены

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = await bot.GetMeAsync(); /// получение всех данных о боте

            Console.WriteLine($"@{me.Username} слушает"); 

            Console.ReadKey();

            cts.Cancel();

            async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
            {
                /// проверка на то, что отправляемое сообщение является допустимым
                if (update.Type != UpdateType.Message)
                    return;

                var chatId = update.Message.Chat.Id; /// чат id

                /// Кнопки с ключевыми словами
                ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                {
                        new KeyboardButton[] { "Мемы", "Фото", "Видео", "Музыка", "/help" },
                })
                {
                    ResizeKeyboard = true
                };

                Console.WriteLine($"Мне пишет: {update.Message.From.FirstName} {update.Message.From.LastName} {update.Message.From.Id}, id чата: {chatId}"); /// информация о пользователе

                /// Блок выполнения кода, если отправлен документ
                if (update.Message!.Type == MessageType.Document)
                {
                    var messageDoc = update.Message.Document; /// присваиваем переменной отправленный документ
                    Console.WriteLine($"Вам отправили: {update.Message.Type}"); /// тип отправленного сообщения
                    Download(messageDoc.FileId, messageDoc.FileName); /// скачивание документа на компьютер
                    return;
                }

                /// Блок выполнения кода, если отправлено фото
                if (update.Message!.Type == MessageType.Photo)
                {
                    var messagePhoto = update.Message.Photo; /// присваиваем переменной отправленное фото
                    Console.WriteLine($"Вам отправили: {update.Message.Type}"); /// тип отправленного сообщения
                    Download(messagePhoto[messagePhoto.Length - 1].FileId, $"Photo_{messagePhoto[messagePhoto.Length - 1].FileId}.jpg"); /// скачивание фото на компьютер
                    return;
                }

                /// Блок выполнения кода, если отправлено аудио
                if (update.Message!.Type == MessageType.Audio)
                {
                    var messageAudio = update.Message.Audio; /// присваиваем переменной отправленное аудио
                    Console.WriteLine($"Вам отправили: {update.Message.Type}"); /// тип отправленного сообщения
                    Download(messageAudio.FileId, messageAudio.FileName); /// скачивание аудио на компьютер
                    return;
                }

                /// Блок выполнения кода, если отправлено видео
                if (update.Message!.Type == MessageType.Video)
                {
                    var messageVideo = update.Message.Video; /// присваиваем переменной отправленное видео
                    Console.WriteLine($"Вам отправили: {update.Message.Type}"); /// тип отправленного сообщения
                    Download(messageVideo.FileId, messageVideo.FileName);  /// скачивание видео на компьютер
                    return;
                }

                /// Блок выполнения кода, если отправлен текст
                if (update.Message!.Type == MessageType.Text)
                {
                    var messageText = update.Message.Text;  /// присваиваем переменной отправленный текст

                    Console.WriteLine($"Сообщение которое мне прислали: {messageText}"); /// отображения текста, которое было прислано

                    /// Команда /start или /help
                    if (messageText == "/start" || messageText == "/help")
                    {
                        await bot.SendTextMessageAsync(chatId, $"Привет, {update.Message.From.FirstName}!\n" +
                            $"Вот, что я могу:\n" +
                            $"- Здороваться\n" +
                            $"- Отвечать на бибу и бобу\n" +
                            $"- Принимать фото, видео, аудио и документы и скачивать их себе на компуктер\n" +
                            $"- Отправлять мемы, фото, видео и музыку (напишите, например, \"Мемы\")", replyMarkup: replyKeyboardMarkup);
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

                    /// Приветствие собеседника
                    if (messageText == "hi" || messageText == "привет" || messageText == "Привет" || messageText == "Hello")
                    {
                        await bot.SendTextMessageAsync(chatId, $"Здравствуй, {update.Message.From.FirstName}!");
                        Console.WriteLine($"Бот ответил: {update.Message.From.FirstName}");
                    }

                    /// Отправка случайных мемов со страницы гитхаба
                    if (messageText == "Мемы")
                    {
                        Random rng = new Random();
                        string path = $"https://github.com/Fu1lerene/Homework-from-the-.NET-Developer-course/raw/main/Homework_9/SentMedia/Memes/Meme_{rng.Next(1, 6)}.jpg";
                        Message messagePhoto = await bot.SendPhotoAsync(chatId, path);
                        Console.WriteLine("Бот отправил мем");
                    }

                    /// Отправка аудио
                    if (messageText == "Музыка")
                    {
                        string path = $"https://github.com/Fu1lerene/Homework-from-the-.NET-Developer-course/raw/main/Homework_9/SentMedia/Audio/Architects - A Wasted Hymn (Acoustic).mp3";
                        Message messagePhoto = await bot.SendAudioAsync(chatId, path);
                        Console.WriteLine("Бот отправил аудио");
                    }

                    /// Отправка фото
                    if (messageText == "Фото")
                    {
                        string path = $"https://raw.githubusercontent.com/Fu1lerene/Homework-from-the-.NET-Developer-course/main/Homework_9/SentMedia/Photo/Mirana.jpg";
                        Message messagePhoto = await bot.SendPhotoAsync(chatId, path);
                        Console.WriteLine("Бот отправил фото");
                    }

                    /// Отправка видео
                    if (messageText == "Видео")
                    {
                        string path = $"https://github.com/Fu1lerene/Homework-from-the-.NET-Developer-course/raw/main/Homework_9/SentMedia/Video/View.mp4";
                        Message messagePhoto = await bot.SendVideoAsync(chatId, path);
                        Console.WriteLine("Бот отправил видео");
                    }

                    return;
                }

                /// Скачивания в указанную папку
                async void Download(string fileId, string path)
                {
                    FileStream fs = new FileStream("F:/Учеба/Programing/Skillbox/Homework_9/DownloadMedia/" + path, FileMode.Create);
                    await bot.GetInfoAndDownloadFileAsync(fileId, fs);
                    fs.Close();
                    fs.Dispose();
                }

            }


            /// Исключения
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
