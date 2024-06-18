using BlazorFluxor.Store.ValueUseCase;

namespace BlazorFluxor.Store
{
    public record EventValueClicked(string[] Items);
    public record SetValueAction(string[] Items);
    public record LoadValuesFromStorageAction(ValueState storedState);
}
