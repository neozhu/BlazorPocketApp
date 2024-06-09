using BlazorPocket.WebAssembly.Components;
using MudBlazor;

namespace BlazorPocket.WebAssembly.Services;

public class DialogServiceHelper
{
    private readonly IDialogService _dialogService;

    public DialogServiceHelper(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    public async Task ShowConfirmationDialog(string title, string contentText, Func<Task> onConfirm, Func<Task>? onCancel = null)
    {
        var parameters = new DialogParameters
        {
            { nameof(ConfirmationDialog.ContentText), contentText }
        };
        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
        var dialog = _dialogService.Show<ConfirmationDialog>(title, parameters, options);
        var result = await dialog.Result;
        if (!result.Canceled)
        {
            await onConfirm();
        }
        else if (onCancel != null)
        {
            await onCancel();
        }
    }
}

