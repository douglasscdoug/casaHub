import { Component, input, output } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faBars, faCalendarDays, faCartShopping, faChevronLeft, faChevronRight, faGear, faHouse, faListCheck, faWallet } from '@fortawesome/free-solid-svg-icons';

@Component({
  imports: [RouterLink, RouterLinkActive, FontAwesomeModule],
  selector: 'app-sidebar',
  styleUrl: './sidebar.css',
  templateUrl: './sidebar.html',
})
export class Sidebar {
  protected readonly faHouse = faHouse;
  protected readonly faWallet = faWallet;
  protected readonly faCartShopping = faCartShopping;
  protected readonly faListCheck = faListCheck;
  protected readonly faCalendarDays = faCalendarDays;
  protected readonly faGear = faGear;
  protected readonly faChevronRight = faChevronRight;
  protected readonly faChevronLeft = faChevronLeft;

  collapsed = input(false);
  toggle = output<void>();
}
