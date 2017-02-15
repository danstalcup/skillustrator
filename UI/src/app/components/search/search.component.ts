import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  
  model1: any;
  arrayOfStrings: string[] = ["this", "is", "array", "of", "text"];

  constructor() { }

  ngOnInit() {
  }

}
