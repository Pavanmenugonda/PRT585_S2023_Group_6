<template>
  <div class="container ">
    <h1 class="text-center">Vue Todo App</h1>
    <!-- Show todos list -->
    <div class="row" v-for="todo in todos" v-bind:key="todo.id">
      <div class="col-md-1 col text-end">
        <input type="checkbox" v-model="todo.done" />
      </div>
      <div class="col-md-3 col text-start">
        <span :class="{ 'line-through': todo.done }">{{ todo.text }} </span>
        
      </div>
      <div class="col-md-1 col text-start">
        <button @click="removeTodo(todo.id)" class="bg-red-500 m-1 p-1">
          X
        </button>
      </div>
    </div>
    <div class="row">
      <!-- Add todo input field -->
      <div class="col-md-4">
        <input type="text" placeholder="Add todo..." v-model="todo" />
      </div>
      <div class="col-md-2 col text-start">
        <button @click="addTodo()" class="bg-green-500 m-1 p-1">Add</button>
        <button @click="clearAllTodos()" class="bg-red-500 m-1 p-1">
          Clear all
        </button>
      </div>
    </div>
  </div>

</template>

<script>
import "@/assets/styles/index.css";
import "bootstrap"; // Import Bootstrap's JavaScript
import "bootstrap/dist/css/bootstrap.css"; // Import Bootstrap CSS

export default {
  name: "App",
  data() {
    return {
      todo: "",
      todos: [
        { id: 1, text: "Learn Vue", done: true },
        { id: 2, text: "Learn React", done: false },
        { id: 3, text: "Learn Angular", done: false },
      ],
    };
  },
  methods: {
    removeTodo: function (id) {
      this.todos = this.todos.filter((todo) => todo.id !== id);
    },
    addTodo: function () {
      if (this.todo) {
        this.todos.push({
          id: this.todos.length + 1,
          text: this.todo,
          done: false,
        });
        this.todo = "";
      }
    },
    clearAllTodos: function () {
      this.todos = [];
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
