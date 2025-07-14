import { render, screen } from "@testing-library/react";
import { describe, expect, it } from "vitest";

import { App } from "./App";

describe("App", () => {
  it("renders properly", async () => {
    render(<App />);

    expect(await screen.findByText("Hello World!")).toBeInTheDocument();
  });
});
