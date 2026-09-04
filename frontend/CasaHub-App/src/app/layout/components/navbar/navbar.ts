import { Component, HostListener } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faBell, faChevronDown, faRightFromBracket, faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  imports: [FontAwesomeModule],
  selector: 'app-navbar',
  styleUrl: './navbar.css',
  templateUrl: './navbar.html',
})
export class Navbar {
  protected readonly faBell = faBell;
  protected readonly faChevronDown = faChevronDown;
  protected readonly faUser = faUser;
  protected readonly faRightFromBracket = faRightFromBracket;

  isUserMenuOpen = false;

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent): void {
    const target = event.target as HTMLElement;

    if (!target.closest('.user-menu')) {
      this.isUserMenuOpen = false;
    }
  }

  @HostListener('document:keydown.escape')
  onEscape(): void {
    this.isUserMenuOpen = false;
  }

  toggleUserMenu(): void {
    this.isUserMenuOpen = !this.isUserMenuOpen;
  }

  closeUserMenu(): void {
    this.isUserMenuOpen = false;
  }
}
