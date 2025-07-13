import { App } from "./App";
import { render, screen } from "./testing/testUtils";

describe("App", () => {
  it("renders properly", async () => {
    render(<App />);

    expect(screen.getByText("Hello world!")).toBeInTheDocument();
  });
});
