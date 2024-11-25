using System;

namespace Tools {
    public class Optional<T> {
        private readonly T _value;
        private bool HasValue { get; set; }

        private Optional() {
            HasValue = false;
        }

        private Optional(T value) {
            _value = value;
            HasValue = true;
        }

        public T Get() => _value;
        public T GetOrDef(T value) => HasValue ? _value : value;
        public T GetOrThr() => HasValue ? _value : throw new Exception("Value is not present");
        public T GetOrThr(Exception e) => HasValue ? _value : throw e;

        public void IfPresent(Action<T> action) {
            if (HasValue) action(_value);
        }

        public void IfPresentOrElse(Action<T> action, Action elseAction) {
            if (HasValue) action(_value);
            else elseAction();
        }

        public static Optional<T> Of(T value) => new(value);

        public static Optional<T> OfNullable(T value) =>
            value == null ? Empty() : new Optional<T>(value);

        public static Optional<T> Empty() => new();
    }
}