import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isMainToggle = true;
  isSubToggle = false;
  isAdminSubToggle = false;
  isVbSubToggle = false;
  isUserSubToggle = false;
  isPoSubToggle = false;
  

  mainMenuToggle(){
    this.isMainToggle = !this.isMainToggle;
  }

  submenuToggle(){
    this.isSubToggle = !this.isSubToggle;
  }

  adminSubmenuToggle(){
    this.isAdminSubToggle = !this.isAdminSubToggle;
  }

  vbSubmenuToggle(){
    this.isVbSubToggle = !this.isVbSubToggle;
  }

  userSubmenuToggle(){
    this.isUserSubToggle = !this.isUserSubToggle;
  }

  poSubmenuToggle(){
    this.isPoSubToggle = !this.isPoSubToggle;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
