import { Component, OnInit } from '@angular/core';

import { Tag } from '../../models/tag';
import { TagsService } from '../../services/tags.service';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.css']
})
export class TagsComponent implements OnInit {
  tags: Tag[];
  newTagName: string;

  constructor(private tagsService: TagsService) { }

  ngOnInit() {
    this.tagsService.getAll().subscribe(tags => this.tags = tags);
  }

  addTag() {
    let newTag = new Tag(this.newTagName);
    this.tagsService.create(newTag).subscribe(tag => {
      this.tags.push(tag);
      this.newTagName = "Test tag";
    });
    
  }
}