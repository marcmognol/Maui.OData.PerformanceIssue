using CommunityToolkit.Mvvm.Input;
using Infrastructure;
using System.Diagnostics;

namespace MauiPerformanceOData;

public partial class MainPage : ContentPage
{
    private int count = 0;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    [RelayCommand]
    public async Task RequestWithODataAsync()
    {
        var startTime = Stopwatch.GetTimestamp();
        await MyODataRepository.GetAsync();
        var stopTime = Stopwatch.GetElapsedTime(startTime).TotalMilliseconds;

        CounterBtn2.Text = $"OData Client: Executed in {stopTime} ms";
    }

    [RelayCommand]
    public async Task RequestWithHttpClientAsync()
    {
        var startTime = Stopwatch.GetTimestamp();
        await MyHttpRepository.GetAsync();
        var stopTime = Stopwatch.GetElapsedTime(startTime).TotalMilliseconds;

        CounterBtn1.Text = $"Http Client: Executed in {stopTime} ms";
    }
}