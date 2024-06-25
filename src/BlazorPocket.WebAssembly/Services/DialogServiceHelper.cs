using BlazorPocket.WebAssembly.Components;
using MudBlazor;

namespace BlazorPocket.WebAssembly.Services;

// This class represents a helper class for the dialog service.
public class DialogServiceHelper
{
    private readonly IDialogService _dialogService;

    public DialogServiceHelper(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    /// <summary>
    /// Shows a confirmation dialog with the specified title and content text.
    /// </summary>
    /// <param name="title">The title of the confirmation dialog.</param>
    /// <param name="contentText">The content text of the confirmation dialog.</param>
    /// <param name="onConfirm">The action to be executed when the confirmation is confirmed.</param>
    /// <param name="onCancel">The optional action to be executed when the confirmation is canceled.</param>
    public async Task ShowConfirmationDialog(string title, string contentText, Func<Task> onConfirm, Func<Task>? onCancel = null)
    {
        var parameters = new DialogParameters
        {
            { nameof(ConfirmationDialog.ContentText), contentText }
        };
        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
        var dialog = _dialogService.Show<ConfirmationDialog>(title, parameters, options);
        var result = await dialog.Result;
        if (result is not null && !result.Canceled)
        {
            await onConfirm();
        }
        else if (onCancel != null)
        {
            await onCancel();
        }
    }
}

