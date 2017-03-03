import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  
  selectedItem: any;
  arrayOfStrings: string[] = ["this", "is", "array", "of", "text"];

  constructor() { }

  ngOnInit() {
  }

  searchBoxItemSelected(event) {
    
  }

} 
