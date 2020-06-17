import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  isExpanded = true;
  showSubmenu: boolean = false;
  isShowing = false;
  showSubSubMenu: boolean = false;

  isMainToggle = false;
  isAdminSubToggle = false;
  isVbSubToggle = false;
  isUserSubToggle = false;
  isPoSubToggle = false;

  nodes = [
    {
      id: 1,
      name: 'root1',
      children: [
        { id: 2, name: 'child1' },
        { id: 3, name: 'child2' }
      ]
    },
    {
      id: 4,
      name: 'root2',
      children: [
        { id: 5, name: 'child2.1' },
        {
          id: 6,
          name: 'child2.2',
          children: [
            { id: 7, name: 'subsub' }
          ]
        }
      ]
    }
  ];
  options = {};
  constructor() { }

  ngOnInit() {
  }
 
  mainMenuToggle(){
    this.isMainToggle = !this.isMainToggle;
  }

  adminSubmenuToggle(){
    this.isAdminSubToggle = !this.isAdminSubToggle;
  }

  voucherBatchSubmenuToggle(){
    this.isVbSubToggle = !this.isVbSubToggle;
  }

  userSubmenuToggle(){
    this.isUserSubToggle = !this.isUserSubToggle;
  }

  purchaseOrderSubmenuToggle(){
    this.isPoSubToggle = !this.isPoSubToggle;
  }

  // mouseenter() {
  //   if (!this.isExpanded) {
  //     this.isShowing = true;
      
  //   }
  // }

  // mouseleave() {
  //   if (!this.isExpanded) {
  //     this.isShowing = false;
  //   }
  // }
}
