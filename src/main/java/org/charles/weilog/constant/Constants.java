package org.charles.weilog.constant;

/**
 * The type Constants.
 */
public class Constants {

    /**
     * The constant POST_TITLE.
     */
    public static final String POST_TITLE = "title"; // 标题
    /**
     * The constant POST_KEYWORDS.
     */
    public static final String POST_KEYWORDS = "keywords"; // 关键字
    /**
     * The constant POST_DESCRIPTION.
     */
    public static final String POST_DESCRIPTION = "description"; // 描述

    /**
     * 文章状态。
     */
    public enum PostStatus {
        /**
         * Publish post status.
         */
        PUBLISH(1, "PUBLISH"),
        /**
         * Auto draft post status.
         */
        AUTO_DRAFT(2, "AUTO_DRAFT"),
        /**
         * Inherit post status.
         */
        INHERIT(2, "INHERIT");

        PostStatus(int code, String description) {
            this.code = code;
            this.description = description;
        }

        private final String description;
        private final int code;
    }

    /**
     * 文章类型。
     */
    public enum PostType {

        /**
         * Post type.
         */
        POST(1, "POST"),

        /**
         * Page type.
         */
        PAGE(2, "PAGE");

        PostType(int code, String description) {
            this.code = code;
            this.description = description;
        }

        private final String description;
        private final int code;
    }
}