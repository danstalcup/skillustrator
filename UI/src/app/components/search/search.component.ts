import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  
  selectedItem: any;
  arrayOfStrings: string[] = [".NET Core", "Angular", "Angular 2", "Azure", "C#", "Javascript", "Rails", "React"];
  edited: boolean;

  constructor() { }

  ngOnInit() {
    this.edited = false;
  }

  searchBoxItemSelected(event) {
    if (this.selectedItem === '.NET Core') {
      this.edited = true;      
    }
    else {
      this.edited = false;
    }
  }

} 
