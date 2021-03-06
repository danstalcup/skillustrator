import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import '../shared/rxjs-operators';
import { Observable } from 'rxjs/observable';

import { HttpService } from './http.service';
import { Person } from '../models/person';

@Injectable()
export class PersonService {
  private headers = new Headers({ 'Content-Type': 'application/json' });
  private apiUrl = '/api/person';

  constructor(private http: Http, private httpService: HttpService) { }

  getAll(): Observable<Person[]> {
    return this.http.get(this.apiUrl)
      .map(res => res.json() as Person[])
      .catch(this.httpService.handleError);
  }

  getById(id: number): Observable<Person> {
    let apiUrlWithId = this.apiUrl + '/' + id;
    return this.http.get(apiUrlWithId)
      .map(res => res.json() as Person)
      .catch(this.httpService.handleError);
  }

  addPersonSkill(personId: number, skillId: number): Observable<Person> {
    let apiUrlWithIds = this.apiUrl + '/' + personId + '/addSkill/' + skillId;
    return this.http.get(apiUrlWithIds)
      .map(res => res.json() as Person)
      .catch(this.httpService.handleError);
  }

  addPersonSkillWithMetadata(personSkill): Observable<Person> {
    let apiUrlWithIds = this.apiUrl + '/' + personSkill.personId + '/addSkill/';

    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = { headers: headers };

    return this.http.post(apiUrlWithIds, JSON.stringify(personSkill), options)
      .map(res => res.json() as Person)
      .catch(this.httpService.handleError);
  }

  removePersonSkill(personId: number, personSkillId: number): Observable<Person> {
    let apiUrlWithIds = this.apiUrl + '/' + personId + '/removeSkill/' + personSkillId;
    return this.http.delete(apiUrlWithIds)
      .map(res => res.json() as Person)
      .catch(this.httpService.handleError);
  }
}
