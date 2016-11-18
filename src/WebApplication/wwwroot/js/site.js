// Write your Javascript code.
Vue.component('todo-item', {
  // The todo-item component now accepts a
  // "prop", which is like a custom attribute.
  // This prop is called todo.
  props: ['todo'],
  template: '<li>{{ todo.text }}</li>'
});

var app = new Vue({
  el: '#app',
  data: {
    groceryList: [
      { text: 'Vegetables' },
      { text: 'Cheese' },
      { text: 'Whatever else humans are supposed to eat' }
    ],
    message: '',
    question: '',
    answer: 'I cannot give you an answer until you ask a question!'
  },
  computed: {
    // a computed getter
    reversedMessage: function () {
      // `this` points to the vm instance
      return this.message.split('').reverse().join('')
    }
  },
  watch: {
    // 如果 question 发生改变，这个函数就会运行
    question: function (newQuestion) {
      this.answer = 'Waiting for you to stop typing...'
      this.getAnswer()
    }
  },
  beforeMount : function() {
    var self = this;
    $.ajax({
        type: 'GET',
        url: 'data/Default/DoAction1?cmd=test',
        success:function(data) {
            self.message = data.message;//JSON.stringify(data);
        }
    });
  },
  methods: {
    reverseMessage: function () {
      this.message = this.message.split('').reverse().join('');
    },
    getAnswer: function() {
      var self = this;
      if (this.question.indexOf('?') === -1) {
          self.answer = 'Questions usually contain a question mark. ;-)';
          return;
        }
        self.answer = 'Thinking...';
      $.ajax({
        type: 'GET',
        url: 'data/Default/DoAction1',
        data:{
          cmd:self.question
        },
        success:function(data) {
            self.answer = data.result;//JSON.stringify(data);
        }
    });
    }
  }
});