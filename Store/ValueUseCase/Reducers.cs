using Fluxor;

namespace BlazorFluxor.Store.ValueUseCase
{
    public class Reducers
    {
        [ReducerMethod]
        public static ValueState ReduceSetValueItem(ValueState state, SetValueAction action)
        {
            return state with { Items = action.Items };
        }

        [ReducerMethod]
        public static ValueState ReduceLoadValuesFromStorageAction(ValueState state, LoadValuesFromStorageAction action)
        {
            return state with
            {
                Items = action.storedState.Items
            };
        }
    }
}
