import { Injectable } from '@angular/core';
import { Headers, RequestOptions, Http } from '@angular/http';

import '../shared/rxjs-operators';
import { Observable } from 'rxjs/observable';

import { HttpService } from './http.service';
import { SkillsMetadata } from '../models/skills-metadata';

@Injectable()
export class MetadataService {
  private headers = new Headers({ 'Content-Type': 'application/json' });
  private apiUrl = '/api/skillsMetadata';

  constructor(private http: Http, private httpService: HttpService) { }

  getAll(): Observable<SkillsMetadata> {
    return this.http.get(this.apiUrl)
      .map(res => res.json() as SkillsMetadata)
      .catch(this.httpService.handleError);
  }
}
