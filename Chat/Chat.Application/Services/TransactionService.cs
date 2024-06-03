using System.Threading.Channels;
using Chat.Application.Models;
using Chat.Application.Services.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Chat.Application.Services;

/// <inheritdoc cref="ITransactionService" />
public class TransactionService : BackgroundService, ITransactionService
{
    private readonly Channel<KeyValuePair<CreateMessageViewModel, Func<CreateMessageViewModel, Task>>> messageQueue;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionService"/> class.
    /// </summary>
    public TransactionService()
    {
        messageQueue = Channel.CreateUnbounded<KeyValuePair<CreateMessageViewModel, Func<CreateMessageViewModel, Task>>>();
    }
    
    /// <inheritdoc />
    public async Task EnqueueMessageAsync(
        CreateMessageViewModel message,
        Func<CreateMessageViewModel, Task> handler)
    {
        var messageHandler = new KeyValuePair<CreateMessageViewModel, Func<CreateMessageViewModel, Task>>(message, handler);
        await messageQueue.Writer.WriteAsync(messageHandler);
    }

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var message in messageQueue.Reader.ReadAllAsync(stoppingToken))
        {
            await Task.Delay(3000, stoppingToken);
            await message.Value.Invoke(message.Key);
        }
    }
}