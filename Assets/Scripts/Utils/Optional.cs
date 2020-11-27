using System;

public class Optional<T> {
  private readonly T value;

  public Optional(T value) {
    this.value = value;
  }

  public Optional() { }

  public void IfPresent(Action<T> consumer) {
    if (value != null) consumer(value);
  }

  public T OrElse(T elseValue) {
    if (value == null) return elseValue;
    return value;
  }

  public T OrElseThrow(Exception exeption) {
    if (value == null) throw exeption;
    return value;
  }
}
