import { slideIn, moveDown, slideOut } from './../animations';
import { Component, ViewEncapsulation } from '@angular/core';
import { trigger, transition, useAnimation, stagger, animateChild, query, group } from '@angular/animations';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.scss'],
  // animation for todo trigger animation transition when add and remove todo
  animations: [
    trigger('todoItem', [
      transition(':enter', [
        useAnimation(slideIn),
      ]),
      transition(':leave', [
        useAnimation(slideOut)
      ]),
    ]),
    trigger('todoAnimations', [
      transition(':enter', [
        group([
          query('h1', [
            useAnimation(moveDown)
          ]),
          query('input', [
            useAnimation(moveDown)
          ]),
          query('@todoItem',
            stagger(100, animateChild()))
        ])
      ])
    ]),
  ],
  
})
export class TodoComponent {
  // todo list
  todos = [
    { title: 'Install Angular CLI', isDone: true },
    { title: 'Style app', isDone: true },
    { title: 'Finish service functionality', isDone: false },
    { title: 'Setup API', isDone: false },
    { title: 'Get data from API', isDone: false },
    { title: 'Create components', isDone: false },
    { title: 'Add router-outlet', isDone: false },
    { title: 'Add navigation', isDone: false },
    { title: 'Deploy to production', isDone: false },
  ];

  // add todo list via an input field
  addTodo(newTodo: HTMLInputElement) {
    if (newTodo) {
      // add new todo to array
      this.todos.push({ title: newTodo.value, isDone: false });
      // clear the input field
      newTodo.value = '';
    }
  }

  // remove todo at index from array
  removeTodo(index: number) {
    this.todos.splice(index, 1);
  }
}
