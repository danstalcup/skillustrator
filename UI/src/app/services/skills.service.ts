import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import '../shared/rxjs-operators';
import { Observable } from 'rxjs/observable';

import { HttpService } from './http.service';
import { Skill } from '../models/skill';

@Injectable()
export class SkillsService {
  private headers = new Headers({ 'Content-Type': 'application/json' });
  private apiUrl = '/api/skills';

  constructor(private http: Http, private httpService: HttpService) { }

  getById(id: number): Observable<Skill> {
    let apiUrlWithId = this.apiUrl + '/' + id;
    return this.http.get(apiUrlWithId)
      .map(res => res.json() as Skill)
      .catch(this.httpService.handleError);
  }
}
