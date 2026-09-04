import { Component } from '@angular/core';
import { Navbar } from "./components/navbar/navbar";
import { Sidebar } from "./components/sidebar/sidebar";
import { RouterOutlet } from "@angular/router";

@Component({
  imports: [Navbar, Sidebar, RouterOutlet],
  selector: 'app-layout',
  styleUrl: './layout.css',
  templateUrl: './layout.html',
})
export class Layout {
  isSidebarCollapsed = false;

  toggleSidebar(): void {
    this.isSidebarCollapsed = !this.isSidebarCollapsed;
  }
}
