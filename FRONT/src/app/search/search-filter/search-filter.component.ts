import { Component, OnInit, Pipe, PipeTransform } from '@angular/core';
import { User } from 'src/app/_models/user';



@Pipe({ name: 'appFilter' })

export class SearchFilter implements PipeTransform {

  transform(items: User[], searchText: string): any[] {
    if (!items) {
      return [];
    }
    if (!searchText) {
      return items;
    }
    searchText = searchText.toLocaleLowerCase();

    return items.filter(it => {
      return it.username.includes(searchText);
    });
  }

}
