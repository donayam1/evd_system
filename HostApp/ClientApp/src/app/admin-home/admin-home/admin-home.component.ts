import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  //isExpanded = true;
  //showSubmenu: boolean = false;
  //isShowing = false;
  //: boolean = false;

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
    if(this.isMainToggle){
      this.isMainToggle =! this.isMainToggle;
      this.isAdminSubToggle = !this.isAdminSubToggle;
    } else {
      this.isAdminSubToggle = !this.isAdminSubToggle;
    }
  }

  voucherBatchSubmenuToggle(){
    if(this.isMainToggle){
      this.isMainToggle =! this.isMainToggle;
      this.isVbSubToggle = !this.isVbSubToggle;
    }else {
      this.isVbSubToggle = !this.isVbSubToggle;
    }
  }

  userSubmenuToggle(){
    if (this.isMainToggle) {
      this.isMainToggle =! this.isMainToggle;
      this.isUserSubToggle = !this.isUserSubToggle;
    }else {
      this.isUserSubToggle = !this.isUserSubToggle;
    }
    
  }

  purchaseOrderSubmenuToggle(){
    if (this.isMainToggle) {
      this.isMainToggle =! this.isMainToggle;
      this.isPoSubToggle = !this.isPoSubToggle;
    } else {
      this.isPoSubToggle = !this.isPoSubToggle;
    }
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
