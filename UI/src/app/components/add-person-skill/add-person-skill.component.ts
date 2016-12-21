import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';

declare var $: JQueryStatic;

@Component({
  selector: 'app-add-person-skill',
  templateUrl: './add-person-skill.component.html',
  styleUrls: ['./add-person-skill.component.css']
})
export class AddPersonSkillComponent implements OnInit, AfterViewInit {
  @ViewChild('addPersonModal') modalEl: ElementRef;

  constructor() { }

  ngOnInit() { }

  ngAfterViewInit() {
    $(this.modalEl.nativeElement).modal();
  }

}
