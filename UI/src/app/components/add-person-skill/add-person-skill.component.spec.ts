/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddPersonSkillComponent } from './add-person-skill.component';

describe('AddPersonSkillComponent', () => {
  let component: AddPersonSkillComponent;
  let fixture: ComponentFixture<AddPersonSkillComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPersonSkillComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPersonSkillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
