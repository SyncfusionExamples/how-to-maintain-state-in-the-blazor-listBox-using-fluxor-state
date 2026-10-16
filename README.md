# Maintain Syncfusion Blazor ListBox State Using Fluxor

## Overview

This sample demonstrates how a Syncfusion [Blazor ListBox](https://www.syncfusion.com/blazor-components/blazor-listbox) can be integrated with Fluxor to manage application state in a centralized and predictable manner.

The application illustrates how ListBox-related data can be stored outside the UI layer and synchronized through Fluxor state management. By using actions, reducers, and shared application state, the sample helps developers understand how to preserve component state, improve maintainability, and build scalable Blazor applications with unidirectional data flow.

## Key Features

- Configures the ListBox using the `DataSource` property with a strongly typed `VehicleData` collection.
- Maps display and value fields through the `ListBoxFieldSettings` component using the `Text` and `Value` properties.
- Handles item selection changes through the `ListBoxEvents` component and the `ValueChange` event.
- Maintains selected ListBox values using Fluxor state management instead of component-local state.
- Dispatches the `EventValueClicked` action whenever the ListBox selection changes.
- Updates application state through Fluxor effects by processing `EventValueClicked` and dispatching `SetValueAction`.
- Stores selected item identifiers in the `ValueState` feature state using the `Items` property.
- Updates state immutably using Fluxor reducer methods defined in the ValueUseCase feature.
- Supports state restoration through the `LoadValuesFromStorageAction` action and corresponding reducer implementation.
- Demonstrates Fluxor Feature State registration using the `[FeatureState]` attribute.
- Uses immutable record-based state containers for Counter, Forecast, and Value feature states.
- Demonstrates Fluxor Effects for handling business logic separately from UI components.
- Demonstrates Fluxor Reducers for predictable and immutable state updates.
- Includes a Counter feature that updates aggregate values through `EventCounterClicked` and `SetCounterTotal` actions.
- Includes a Forecast feature that asynchronously streams weather data using `IAsyncEnumerable<WeatherForecast>`.
- Demonstrates asynchronous Fluxor effects using the `[EffectMethod]` attribute.
- Simulates real-time forecast loading with incremental state updates dispatched through the `SetForecast` action.
- Implements error handling and timeout management using the `SetDbError` action.
- Uses immutable collections (`ImmutableList<WeatherForecast>`) for storing forecast data safely.
- Integrates Redux DevTools support during development through the `UseReduxDevTools()` configuration.
- Registers Fluxor services automatically using assembly scanning with `options.ScanAssemblies(typeof(Program).Assembly)`.
- Includes reusable Razor components such as `OKDialog`, `ShowError`, `TemplatedDialog`, and a generic `TableTemplate<TItem>` component.
- Demonstrates reusable templated UI patterns using `RenderFragment` and `RenderFragment<TItem>`.
- Uses dependency injection to access Fluxor `IDispatcher` and `IState<T>` services within Blazor components.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone or download this repository.
2. Open `BlazorFluxor.sln`.
3. Restore all NuGet packages.
4. Build the solution.
5. Run the application using `Ctrl+F5`.

**Visual Studio Code**

1. Clone or download the repository.
2. Open the repository folder in Visual Studio Code.
3. Navigate to the project directory.

```bash
cd BlazorFluxor
dotnet restore
dotnet run
```

4. Open the URL displayed in the terminal after the application starts.

## Project Structure

- `Program.cs` - Configures the Blazor Server application, registers Fluxor, enables Redux DevTools support, and registers Syncfusion Blazor services.

### Pages

- `Pages/Index.razor` - Main sample page demonstrating Syncfusion ListBox selection persistence using Fluxor state management.

### Components

- `Components/OKDialog.razor` - Reusable dialog component with configurable heading, body content, and OK action callback.
- `Components/ShowError.razor` - Reusable error display component that conditionally renders error content using the `IsShow` parameter.

### Shared Components

- `Shared/TemplatedDialog.razor` - Generic dialog container component that renders arbitrary content using `RenderFragment`.
- `Shared/TableTemplate.razor` - Generic templated table component that supports customizable headers and row templates through `RenderFragment<TItem>`.

### Fluxor State Management

#### Counter Feature

- `Store/CounterUseCase/CounterState.cs` - Defines the `CounterState` feature state containing the `TotalCount` value.
- `Store/CounterUseCase/Effects.cs` - Processes counter-related actions and dispatches updated totals.
- `Store/CounterUseCase/Reducers.cs` - Handles immutable counter state updates.
- `Store/CounterAction.cs` - Defines counter actions including `EventCounterClicked` and `SetCounterTotal`.

#### Value Feature

- `Store/ValueUseCase/ValueState.cs` - Stores selected ListBox item values.
- `Store/ValueUseCase/Effects.cs` - Processes ListBox selection changes and dispatches state update actions.
- `Store/ValueUseCase/Reducers.cs` - Updates selected item values and restores persisted state.
- `Store/SetValueAction.cs` - Defines actions used for selection updates and state loading.

#### Forecast Feature

- `Store/ForecastUseCase/ForecastState.cs` - Defines forecast state including weather data, loading status, and error information.
- `Store/ForecastUseCase/Effects.cs` - Streams weather forecast data asynchronously and manages timeout handling.
- `Store/ForecastUseCase/Reducers.cs` - Processes forecast, loading, and error state updates.
- `Store/ForecastActions.cs` - Defines forecast-related actions including initialization, data updates, error handling, and state reset operations.

### Data Models

- `Pages/Index.razor` (VehicleData class) - Defines the model used by the Syncfusion ListBox component.
- `Data/WeatherForecast.cs` - Weather forecast model referenced by the Forecast Fluxor feature.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- Official Documentation: https://blazor.syncfusion.com/documentation/listbox/getting-started

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.