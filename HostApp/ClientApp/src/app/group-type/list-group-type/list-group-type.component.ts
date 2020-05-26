import { Component, OnInit } from '@angular/core';
import { GrouptypeService } from 'src/app/data/GroupType/Services/grouptype.service';

@Component({
  selector: 'app-list-group-type',
  templateUrl: './list-group-type.component.html',
  styleUrls: ['./list-group-type.component.css']
})
export class ListGroupTypeComponent implements OnInit {
  grouptype: any[];

  constructor( private grouptypeService :GrouptypeService) { }

  ngOnInit() {
     this.grouptypeService.getGroupType();
  }

}
