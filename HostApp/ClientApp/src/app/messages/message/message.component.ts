import { Component, OnInit } from '@angular/core';
import { Message, ResponseBase } from 'src/app/data/Shared/Models/responseBase';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {

  responses: ResponseBase[];
  constructor() {
    this.responses = Array();
  }

  ngOnInit() {
  }

  addMessages(responseBase: ResponseBase) {
    this.responses.push(responseBase);
  }

}
